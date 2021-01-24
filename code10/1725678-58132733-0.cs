            AdomdConnection conn = new AdomdConnection(ConnStr);
            conn.Open();
            List<string> cubeName = new List<string>();
            List<string> dimensions = new List<string>();
            List<string> hierarchyList = new List<string>();
            List<string> levels = new List<string>();
            foreach (CubeDef cube in conn.Cubes)
            {
                cubeName.Add(cube.Name.ToString());
                foreach (Dimension dimension in cube.Dimensions) 
                {
                    dimensions.Add(dimension.Name.ToString());
                    foreach (Hierarchy hierarchy in dimension.Hierarchies) 
                     {
                        hierarchyList.Add(hierarchy.Name.ToString());
                        foreach (Level level in hierarchy.Levels) 
                        {
                            levels.Add(level.Name.ToString());
                        }
                    }
                }
            }
          var data = new { cubeName,dimensions,hierarchyList,levels  };    
                                                                                           
         return data
