    foreach (var dr in DriveInfo.GetDrives())
        {
            if (dr.IsReady == true)
            {
                Console.WriteLine(string.Format("name : {0}   type : {1}", dr, dr.DriveType));
            }
        }
