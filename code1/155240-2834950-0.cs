        while (reader.Peek() >= 0 && count < offset.Size)
        {
            char c = (char)reader.Read();
            if (c != ' ' && c != '\r' && c != '\n')
            {
                builder.Append(c);
                count++;
            }
            //else
            //{
            //    reader.BaseStream.Position++;
            //}
        }
