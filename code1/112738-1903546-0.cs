try{
  FileInfo fi = new FileInfo(filePath); 
  using (FileStream fs = fi.Open (FileMode.Create, FileAccess.Write, FileShare.None)) 
  { 
    fs.Write(byteData, 0, byteData.Length); 
    fs.Flush();
    fs.Close();
  }
}catch(System.IO.IOException ioEx){
  Console.WriteLine("IOException caught: {0}", ioEx.ToString());
} 
