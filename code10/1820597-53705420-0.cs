    public class Fruit : ISelectInfo {
        public bool Rule(string rule){ 
            return "fruit".Equals(rule); 
        }
        public async Task<IEnumerable<FoodDto>> ReturnSearchResult(string query){
            // returns a list of FoodDto
        }
    }
