    foreach (var item in DriveInfo.GetDrives())
            {
                //VolumeLabel differs from a scanner to another
                if (item.VolumeLabel == "Photo scan" && item.DriveType == DriveType.Removable)
                {
                    foreach (var obj in Directory.GetFiles(item.Name))
                    {
                        File.Copy(obj, "[YOUR NEW PATH]");
                        break;
                    }
                    break;
                }
            }
