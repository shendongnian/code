    public class GroupFieldArgSender
    {
      public string GroupName  { get; set; }
      public int AggregateValue { get; set; }
      public void RebroadcastEventWithRequiredData(object sender, EventArgs e)
      {
        if (GroupFieldEvent != null)
        {
          GroupFieldEvent(sender, new GroupFieldEvent
            { GroupName = GroupName, AggregateValue = AggregateValue });
        }
      }
      public event EventHandler<GroupFieldEventArgs> GroupFieldEvent;
    }
