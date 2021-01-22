    // On MasterPage
    public Timer MyTimer { get { return this._myTimer; } }
 
    // On Content Page
    <%@ MasterType VirtualPath="~/MyMaster.master" %>
    override OnLoad(EventArgs e) {
        base.OnLoad(e);
        this.Master.MyTimer.Enabled = false;
    }
