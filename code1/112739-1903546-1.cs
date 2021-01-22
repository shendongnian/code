try{
  FileInfo fi = new FileInfo(filePath); 
  using (FileStream fs = fi.Open (FileMode.Create, FileAccess.Write, FileShare.None)) 
  { 
    fs.Write(byteData, 0, byteData.Length); 
    fs.Flush();
    fs.Close();
  }
}catch(System.Security.SecurityException secEx){
  Console.WriteLine("SecurityException caught: {0}", secEx.ToString());
}catch(System.IO.IOException ioEx){
  Console.WriteLine("IOException caught: {0}", ioEx.ToString());
} 
