    public override void ViewDidLoad ()     
    {       
       base.ViewDidLoad ();
       this.lbl_Werkt.Text = "het werkt wtf";
       try{
          XmlDocument Doc = new XmlDocument();
          string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\ClassData.xml");
           
           if(!file.Exists(path))
              throw new IOExpection("File not found");
             
           Doc.Load(path);
    
           foreach (XmlNode node in Doc.SelectNodes("//Warrior"))
           {
              string Name = node["Name"].InnerText;
              lbl_Name.Text = Name;
           }
        }
        catch(IOException ioEx)
        {
           Console.WriteLine("The File could not be read:");
           Console.WriteLine(ioEx.Message);
        }
        catch(Exception ex)
        {
           Console.WriteLine(ex.Message);
        }
    }  
