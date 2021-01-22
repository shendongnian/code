    foreach (DriveInfo objDrive in DriveInfo.GetDrives())
        {
            Response.Write("</br>Drive Type : " + objDrive.Name);
            Response.Write("</br>Drive Type : " + objDrive.DriveType.ToString());
            Response.Write("</br>Available Free Space : " + objDrive.AvailableFreeSpace.ToString() + "(bytes)");
            Response.Write("</br>Drive Format : " + objDrive.DriveFormat);
            Response.Write("</br>Total Free Space : " + objDrive.TotalFreeSpace.ToString() + "(bytes)");
            Response.Write("</br>Total Size : " + objDrive.TotalSize.ToString() + "(bytes)");
            Response.Write("</br>Volume Label : " + objDrive.VolumeLabel);
            Response.Write("</br></br>");
        }
