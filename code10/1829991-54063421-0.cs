    public class ViewModelBase {
        public string SearchText {get;}
        
        public ViewModelBase(string searchText) {
    		SearchText = searchText;
        }
    }
    public class ListModel : ViewModelBase {
    	public ListModel( ..., searchText) : base(searchText) {
    		...
    	}
    }
In _Layout, set the model type and you'll have access to the ViewModeBase properties and pass the searchText value in the call to render the menu. 
    <!-- _Layout (approximate markup) -->
    @model ViewModelBase
    <html>
    <head></head>
    <body>
        @Html.Action("Menu", "Nav", Model.SearchText)
        <div>
            @RenderBody()
        </div>
    </body>
    </html>
