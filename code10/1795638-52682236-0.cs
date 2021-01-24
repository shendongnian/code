    <%@ Control Language="C#" ClassName="Dates" %>
    <script runat="server">
        public DateTime ArivvalDate
        {
            get { return Arivval.SelectedDate; }
            set { Arivval.SelectedDate = value; }
        }
        public DateTime DepartureDate
        {
            get { return Depart.SelectedDate; }
            set { Depart.SelectedDate = value; }
        }
    </script>
    <b>Arivval Date: </b><br />  <br />
        <asp:Calendar runat="server" ID="Arivval" ></asp:Calendar><br />
     <b>Depart Date: </b> <br /> <br />
     <asp:Calendar runat="server" ID="Depart" ></asp:Calendar>
