    [Fact]
            public async Task Calculation_Xls()
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string filesDirectory = currentDirectory + "\\Files";
                System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                Configuration = builder.Build();
                var optionsBuilder = new DbContextOptionsBuilder<RetContext>();
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                int i = 0; //outer loop
                UnitOfWork uow = new UnitOfWork(new RetContext(optionsBuilder.Options));
                using (var stream = System.IO.File.Open(filesDirectory + "\\t2UserProfileDataTwoUserPerSpecialty.xlsx",
                    FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        do
                        {
                            while (reader.Read())
                            {
                                if (i != 0)
                                {
                                    var userId = reader.GetString(0);
                                    var specialtyCode = reader.GetString(1);
                                    var userProfileElement1_WorkExp = reader.GetValue(2);
                                    var userProfileElement2_VolExp = reader.GetValue(3);
                                    var userProfileElement3_ResExp = reader.GetValue(4);
                                    var userProfileElement4_Pubs = reader.GetValue(5);
                                    var userProfileElement5_AOA = reader.GetValue(6);
                                    var userProfileElement6_Nspecialties = reader.GetValue(7);
                                    var userProfileElement7_PercentApps = reader.GetValue(8);
                                    //Create profile
                                    UserProfileData profile = new UserProfileData();
                                    profile.UserProfileElement1_WorkExp = Convert.ToInt32(userProfileElement1_WorkExp);
                                    profile.UserProfileElement2_VolExp = Convert.ToInt32(userProfileElement2_VolExp);
                                    profile.UserProfileElement3_ResExp = Convert.ToInt32(userProfileElement3_ResExp);
                                    profile.UserProfileElement4_Pubs = Convert.ToInt32(userProfileElement4_Pubs);
                                    profile.UserProfileElement5_Aoa = Convert.ToBoolean(userProfileElement5_AOA);
                                    profile.UserProfileElement6_Nspecialties = Convert.ToInt32(userProfileElement6_Nspecialties);
                                    profile.UserProfileElement7_PercentApps = Convert.ToInt32(userProfileElement7_PercentApps);
                                    //Calculate for set of programs. Selects one row at a time from XLS. BulkInsert into DB
                                    //THIS ONLY RUNS ONE LINE OF THE METHOD
                                     var backgroundTask = await Task.Run(() =>  CalculateSet(uow, profile, userId, specialtyCode ));
                                    //THIS WORKS
                                    //CalculateSet(uow, profile, userId, specialtyCode);
                                }
                                i++;
                                Debug.WriteLine("Bulkcreate complete " + i);
                                //only process xxx rows
                                if (i > 1)
                                {
                                    break;
                                }
                            }
                        } while (reader.NextResult());
                    }
                }
                Debug.WriteLine("Should get here quickly and not wait until task is done");
            }
            private void CalculateSet(UnitOfWork uow, UserProfileData profile, string userId, string specialtyCode)
            {
                //I CAN HIT THIS BREAKPOINT!
                //get specialtyId from code
                var specialtyId = uow.RefMedicalSpecialtyRepository
                     .Find(x => x.Code == specialtyCode).FirstOrDefault().Id;
                //NEVER GET TO THIS BREAKPOINT
                //loop through all programs for speciality
                var programsForSpecialty = uow.RefProgramDetailDataRepository
                    .Find(x => x.RefMedicalSpecialtyId == specialtyId);
                //List for bulk insert
               // List<UserProgram> userPrograms = new List<UserProgram>();
                //Write a row for each program
                foreach (RefProgramDetailData rpdd in programsForSpecialty.ToList())
                {
                    //Get program info
                    var programProfile = LoadData.Load_RefProgramProfileData(rpdd.Code);
                    //Calculate results
                    var userProgram = _calculator.CalculateAll(programProfile, profile, specialtyId, userId);
                    //If the Program can not be found in program detail then skip insert
                    if (userProgram == null)
                    {
                        Debug.WriteLine("Program NULL");
                    }
                    else
                    {
                        //Write results to UserProgram
                         uow.UserProgramRepository.Create(userProgram);
                        //userPrograms.Add(userProgram);
                        Debug.WriteLine("Program " + programProfile.ProgramCode);
                    }
                }
                //bulk insert
               // uow.UserProgramRepository.BulkCreate(userPrograms);
            }
        }
