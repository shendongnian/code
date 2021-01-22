    Html.DropDownList("Games[" + i + "].HomeTeamId", 
        new SelectList(Model.Teams, Model.Games[i].HomeTeamId));
    public class RoundViewModel
    {
        ....
        public IList<TeamObject> Teams { get; private set; }
