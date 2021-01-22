        [ActiveRecord("cpa_events")]
	public class Event : ARBase<Event>
	{
             private IList<Interfaces.IMember> _members = new List<Interfaces.IMember>();
             [HasManyToAny(typeof(Interfaces.IMember),"event_id","cpa_events_members",       typeof(int), "member_type", "member_id", MetaType=typeof(string))]
             [Any.MetaValue("User", typeof(User))]
		     [Any.MetaValue("Client", typeof(Client))]
		     public IList<Interfaces.IMember> Members
		     {
			    get { return _members; }
			    set { _members = value; }
		     }
        }
