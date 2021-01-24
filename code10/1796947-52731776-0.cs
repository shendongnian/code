        writer.WriteLine("GetPosition");
        writer.Flush();
        
        //Just like you did you should seperate the payload
        //Either by size or new line or some special key you set
        byte[] buffer = new byte[1024];
        stream.Read(buffer, 0, buffer.Length);
        using (var ms = new MemoryStream(buffer))
        {
            var gazePos = (GazePosition)positionSerializer.Deserialize(ms);
            //DOSTUFF
        }
        //Added code finished
