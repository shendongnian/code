    void Main()
    {
    	var vApp = MyExtensions.GetRunningVisio();
    	var shp = vApp.ActiveWindow.Selection.PrimaryItem;
    	for (short i = 0; i < shp.GeometryCount; i++)
    	{
    		var geoSectIdx = (short)(Visio.VisSectionIndices.visSectionFirstComponent + i);
    		var geoName = $"Geometry{i + 1}";
    		$"{shp.NameID}!{geoName}".Dump();
    		for (short r = 1; r < shp.Section[geoSectIdx].Count; r++)
    		{
    			var rowTag = shp.RowType[geoSectIdx, r];
    			$"Row.{r} = {Enum.GetName(typeof(Visio.VisRowTags), rowTag)}".Dump();
    		}
    		"".Dump();
    	}
    }
