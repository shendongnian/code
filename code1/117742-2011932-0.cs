    public abstract class ProcessBlock
    {
        public abstract Color GetDrawingColor();
    }
    
    public class ProcessBlockA : ProcessBlock
    {
        public override Color GetDrawingColor() 
        { 
           return Color.Blue; 
        }
    }
    
    public class ProcessBockB : ProcessBlock
    {
        public override Color GetDrawingColor() 
        { 
           return Color.Red;
        }
    
    }
    
    public ProcessBlockVisualizer : UserControl
    {
        private ProcessBlock _pb;
        public ProcessBlockVisualizer( ProcessBlock pb )
        { 
             _pb = pb;
             this.BackgroundColor = _pb.GetDrawingColor();
             this.PropertyGrid.Datasource =pb;
        }           
    }
