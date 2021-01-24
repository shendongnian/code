     using (FileStream fs = new FileStream("E:\\cnp.mp4",
                               FileMode.Open,
                               FileAccess.Read))
            {
                dynamic parameters = new System.Dynamic.ExpandoObject();
                parameters.upload_phase = "start";
                parameters.file_size = fs.Length;
                var fileSize = (int)fs.Length;
                Console.WriteLine("file_size: {0}", fileSize);
                dynamic result = fb.Post("/" + FBAccountID + "/advideos", parameters);
                string upload_session_id = (string)result["upload_session_id"];
                Console.WriteLine("");
                Console.WriteLine("upload_session_id: {0}", (string)result["upload_session_id"]);
                Console.WriteLine("Video Id: {0}", (string)result["video_id"]);
                Console.WriteLine("");
                Console.WriteLine("start_offset: {0}", (string)result["start_offset"]);
                Console.WriteLine("end_offset: {0}", (string)result["end_offset"]);
                int startOffset = int.Parse((string)result["start_offset"]);
                int endOffset = int.Parse((string)result["end_offset"]);
                int length = endOffset - startOffset;
                int i = 1;
                int totalBytesRead = 0;
                BinaryReader br = new BinaryReader(fs);
                while (startOffset < endOffset)
                {                   
                     byte[] buff = new byte[length];
                     fs.Read(buff, 0, length);
                    totalBytesRead += buff.Length;                
                    Console.WriteLine("buff length: {0}", buff.Length);
                    Console.WriteLine("Total Bytes Read: {0}", totalBytesRead);
                    dynamic parameters1 = new System.Dynamic.ExpandoObject();
                    parameters1.upload_phase = "transfer";
                    parameters1.upload_session_id = upload_session_id;
                    parameters1.start_offset = startOffset;
                    parameters1.video_file_chunk = new FacebookMediaObject { ContentType = "video/mp4", FileName = "cnp " + i + ".mp4" }.SetValue(buff);
                    i++;
                    dynamic result1 = fb.Post("/" + FBAccountID + "/advideos", parameters1);
                    Console.WriteLine("");
                    Console.WriteLine("start_offset: {0}", (string)result1["start_offset"]);
                    Console.WriteLine("end_offset: {0}", (string)result1["end_offset"]);
                    startOffset = int.Parse((string)result1["start_offset"]);
                    endOffset = int.Parse((string)result1["end_offset"]);
                    length = endOffset - startOffset;
                }
                dynamic parameters2 = new System.Dynamic.ExpandoObject();
                parameters2.upload_phase = "finish";
                parameters2.upload_session_id = upload_session_id;
                parameters2.title = "Video title";
                dynamic result2 = fb.Post("/" + FBAccountID + "/advideos", parameters2);
                Console.WriteLine("success: {0}", result2["success"].ToString());
