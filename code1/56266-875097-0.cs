    public interface IDisplayModel
    {
    	string DisplayText{get;set;}
    	string ImageUrl{get;set;}
    	string AltText{get;set;}
    }
    
    public interface ITrustGrid<T> where T : IDisplayModel
    {    
    	IPagedList<T> Elements { get; set; }    
    	IList<IColumn<T>> Columns { get; set; }    
    	IList<string> Headers { get; }
    }
    
    <%@ Control Language="C#" 
        Inherits="System.Web.Mvc.ViewUserControl<ITrustGrid<IDisplayModel>>" %>
