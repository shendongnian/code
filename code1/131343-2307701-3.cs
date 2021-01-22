    <%
    var parameters = (string[])data;
    var namespaceName = parameters[0];
    var className = parameters[1];
    %>
    namespace <%= namespaceName %>
    {
        public class <%= className %>
        {
        }
    }
