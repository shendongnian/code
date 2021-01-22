    <%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DeleteMeQuestion.Models.QuizModel>" %>
    <asp:Content ContentPlaceHolderID="TitleContent" runat="server">
        Home Page
    </asp:Content>
    <asp:Content ContentPlaceHolderID="MainContent" runat="server">
        <% using (Html.BeginForm()) { %>
            <div>
                <h1><%: Model.QuestionDisplayText %></h1>
                <div>
                <ul>
                <% foreach (var item in Model.Responses) { %>
                    <li>
                        <%= Html.RadioButtonFor(m => m.SelectedResponse, item.ResponseId, new {id="Response" + item.ResponseId}) %>
                        <label for="Response<%: item.ResponseId %>"><%: item.ResponseDisplayText %></label>
                    </li>
                <% } %>
                </ul>
                <%= Html.ValidationMessageFor(m => m.SelectedResponse) %>
            </div>
            <input type="submit" value="Submit" />
        <% } %>
    </asp:Content>
