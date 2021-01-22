               string serialFilePath = @"E:\test\serialFiles\DataFile.dat";               
                FileStream myFS = new FileStream(serialFilePath, FileMode.Open);
                // Create a binary formatter object to deserialize the data
                BinaryFormatter myBF = new BinaryFormatter();
    
                MyCustomFlash flashObj;
              //where class MyCustomFlash : AxShockwaveFlashObjects.AxShockwaveFlash, ISerializable
    
                flashObj = (MyCustomFlash)myBF.Deserialize(myFS);
               //this is code from VS designer..need to initialise flash control
                ((System.ComponentModel.ISupportInitialize)(flashObj)).BeginInit();
                myFS.Close();
                flashObj.Enabled = true;
                this.Controls.Add(flashObj);
                ((System.ComponentModel.ISupportInitialize)(flashObj)).EndInit();
                
                flashObj.Name = "Axflash";
                flashObj.Visible = true;
                flashObj.Location = new System.Drawing.Point(12, 12);
                flashObj.Size = new System.Drawing.Size(309, 207);
