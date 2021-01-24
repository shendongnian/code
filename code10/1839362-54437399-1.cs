    public partial class CanvasControl : System.Windows.Window,          
             System.Windows.Markup.IComponentConnector {
       this.canvasImages.PreviewMouseDown += new                       
       System.Windows.Input.MouseButtonEventHandler 
        (this.PreviewMouseDown);
            
       this.canvasImages.PreviewMouseUp += new                   
        System.Windows.Input.MouseButtonEventHandler 
           (this.PreviewMouseUp);
            
       this.canvasImages.PreviewMouseMove += new 
        System.Windows.Input.MouseEventHandler        
            (this.PreviewMouseMove);
    }
