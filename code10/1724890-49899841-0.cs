    var position = stream.Position; // < save
    stream.Lock(position, data.LongLength);
    Console.WriteLine("Data locked. Press any key for continuation...");
    stream.Write(data, 0, data.Length); // < this changes stream.Position, breaking your old logic
    stream.Flush();
    // I get the Exception here: 
    // The blocking of the segment already taken off.
    stream.Unlock(position, data.LongLength); // < now you unlock the same range
