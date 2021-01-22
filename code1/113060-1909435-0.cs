    public class CombinationCondition : ICondition {
    private List<ICondition> list;
    public CombinationCondition(List<ICondition> list) {
        this.list = list;
    }
    
    // if you need it
    public void AddCondition( ICondition condition ){
        list.Add( condition );
    }
    // Still Magic!!!
    public bool SatisfiedBy(Something something) {
        return list.Any( x => x.SatisfiedBy( something ) );
    }
