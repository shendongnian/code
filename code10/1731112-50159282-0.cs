	// write
	BinaryWriter Writer = new BinaryWriter(File.Open(FileName, FileMode.Create));;
	Writer.Write(this.Point.X); Writer.Write(this.Point.Y); Writer.Write(this.Point.Z);
	Writer.Write(this.Point.X); Writer.Write(this.Point.Y); Writer.Write(this.Point.Z);  
	Writer.Write(this.Point.X); Writer.Write(this.Point.Y); Writer.Write(this.Point.Z);
	Writer.Write(this.Point.X); Writer.Write(this.Point.Y); Writer.Write(this.Point.Z);    
	Writer.Flush();
	Writer.Close();
	// read
	BinaryReader Reader = new BinaryReader(File.Open(FileName, FileMode.Open));
	this.Point.X = Reader.ReadDouble(); this.Point.Y = Reader.ReadDouble(); this.Point.Z = Reader.ReadDouble();    
	this.Point.X = Reader.ReadDouble(); this.Point.Y = Reader.ReadDouble(); this.Point.Z = Reader.ReadDouble();    
	this.Point.X = Reader.ReadDouble(); this.Point.Y = Reader.ReadDouble(); this.Point.Z = Reader.ReadDouble();    
	this.Point.X = Reader.ReadDouble(); this.Point.Y = Reader.ReadDouble(); this.Point.Z = Reader.ReadDouble();
	Reader.Close();
