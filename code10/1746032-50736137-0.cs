       using (System.IO.Stream fileData = System.IO.File.OpenRead(TestFilenamePath))
            {
                string filenamePath = aBillModel.UploadedBill.Path + filename;
                using (System.IO.FileStream newFileData = System.IO.File.Create(filenamePath))
                {
                    fileData.Position = 0;
                    fileData.CopyTo(newFileData);
                }
            
                fileData.CopyTo(aBillModel.UploadedBill.FileDataStream);
                //Perform Action to be tested
                bool emailSendt = EmailSender.Send(aBillModel);
                //Test Result of Action
                Assert.That(emailSendt, Is.True);
            }
