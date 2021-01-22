     public class SaveableEvaluationRepository : ISaveableRepository {
       public ISaveable getSavable(int id) {
           //Add your logic here to retrieve your evaluations, although I think that 
           //this logic would belong elsewhere, rather than the saveable interface.
       }
       
       public Save(ISaveable saveable) {
           saveable.SaveFields();
       }
     }
