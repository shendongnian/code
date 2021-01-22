     <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Tameside.Internal.ViewModels.BuyWithConfidence.DropDownViewModel>>" %>
     <select>
	     <% foreach(var category in Model.Categories) { %>
		     <option value="<%= Html.Encode(category.Id) %>"><%= Html.Encode(category.Name %></option>
	     <% } %>
     </select>
