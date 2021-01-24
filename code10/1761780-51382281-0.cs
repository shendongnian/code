            foreach (var singleFile in files)
                {
                //Create the StreamContent of the input file and add to the MultpartContent
                StreamContent is1 = new StreamContent(singleFile.InputStream);
                is1.Headers.ContentType = new MediaTypeHeaderValue(singleFile.ContentType);
                is1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                is1.Headers.ContentDisposition.Name = singleFile.FileName;
                is1.Headers.ContentDisposition.FileName = x+ singleFile.FileName;
                content.Add(is1);
                x++;
                }
