      private void saveCanvas()
            {
                SaveFileDialog save = new SaveFileDialog();
                save.DefaultExt = ".shapes";
                save.Filter = "Shapes File (*.shapes) |*.shapes";
    
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.Delete(save.FileName);
                    var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects, NullValueHandling = NullValueHandling.Ignore };
                    File.WriteAllText(save.FileName, JsonConvert.SerializeObject(shapes, shapes.GetType(), settings));
                }
            }
           
    
            private void loadCanvas()
            {
                List<APShape> shapeList = new List<APShape>();
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Shapes File (*.shapes) |*.shapes";
    
                if (open.ShowDialog() == DialogResult.OK)
                {
                    shapes.Clear();       /* Clear canvas to make sure we are starting blank */
                    canvas.Invalidate();
    
                    var json = File.ReadAllText(open.FileName);
                    var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects, NullValueHandling = NullValueHandling.Ignore };
    
                    shapeList = JsonConvert.DeserializeObject<List<APShape>>(json, settings);
    
                    foreach (var shape in shapeList)
                    {
                        shapes.Add(shape);
                    }
                    canvas.Invalidate();      
                }
        }
