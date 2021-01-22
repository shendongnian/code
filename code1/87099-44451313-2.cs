                    DriveInfo[] allDrives = DriveInfo.GetDrives();
                    int drive = 1;
                    foreach (DriveInfo d in allDrives)
                    {
                        if (drive == 1)
                        {
                            drivename = String.Format("Drive {0}", d.Name);
                            drivetype = String.Format("Drive type: {0}", d.DriveType);
                            if (d.IsReady == true)
                            {
                                drivevolumelabel = String.Format("Volume label: {0}", d.VolumeLabel);
                                drivefilesystem = String.Format("File system: {0}", d.DriveFormat);
                                driveuseravailablespace = String.Format("Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);
                                driveavailablespace = String.Format("Total available space:{0, 15} bytes", d.TotalFreeSpace);
                                drivetotalspace = String.Format("Total size of drive:{0, 15} bytes ", d.TotalSize);
                            }
                            drive = 2;
                        }
                        else if (drive == 2)
                        {
                            drivename2 = String.Format("Drive {0}", d.Name);
                            drivetype2 = String.Format("Drive type: {0}", d.DriveType);
                            if (d.IsReady == true)
                            {
                                drivevolumelabel2 = String.Format("Volume label: {0}", d.VolumeLabel);
                                drivefilesystem2 = String.Format("File system: {0}", d.DriveFormat);
                                driveuseravailablespace2 = String.Format("Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);
                                driveavailablespace2 = String.Format("Total available space:{0, 15} bytes", d.TotalFreeSpace);
                                drivetotalspace2 = String.Format("Total size of drive:{0, 15} bytes ", d.TotalSize);
                            }
                            drive = 3;
                        }
                        else if (drive == 3)
                        {
                            drivename3 = String.Format("Drive {0}", d.Name);
                            drivetype3 = String.Format("Drive type: {0}", d.DriveType);
                            if (d.IsReady == true)
                            {
                                drivevolumelabel3 = String.Format("Volume label: {0}", d.VolumeLabel);
                                drivefilesystem3 = String.Format("File system: {0}", d.DriveFormat);
                                driveuseravailablespace3 = String.Format("Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);
                                driveavailablespace3 = String.Format("Total available space:{0, 15} bytes", d.TotalFreeSpace);
                                drivetotalspace3 = String.Format("Total size of drive:{0, 15} bytes ", d.TotalSize);
                            }
                            drive = 4;
                        }
                        if (drive == 4)
                        {
                            drive = 1;
                        }
                    }
                    //part 2: possible debug - displays in output
                    //drive 1
                    Console.WriteLine(drivename);
                    Console.WriteLine(drivetype);
                    Console.WriteLine(drivevolumelabel);
                    Console.WriteLine(drivefilesystem);
                    Console.WriteLine(driveuseravailablespace);
                    Console.WriteLine(driveavailablespace);
                    Console.WriteLine(drivetotalspace);
                    //drive 2
                    Console.WriteLine(drivename2);
                    Console.WriteLine(drivetype2);
                    Console.WriteLine(drivevolumelabel2);
                    Console.WriteLine(drivefilesystem2);
                    Console.WriteLine(driveuseravailablespace2);
                    Console.WriteLine(driveavailablespace2);
                    Console.WriteLine(drivetotalspace2);
                    //drive 3
                    Console.WriteLine(drivename3);
                    Console.WriteLine(drivetype3);
                    Console.WriteLine(drivevolumelabel3);
                    Console.WriteLine(drivefilesystem3);
                    Console.WriteLine(driveuseravailablespace3);
                    Console.WriteLine(driveavailablespace3);
                    Console.WriteLine(drivetotalspace3);
