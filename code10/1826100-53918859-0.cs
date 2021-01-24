    public List<string> GenerateScheduler(int workHours, int dayHours, string pattern){
        int remainingSum = workHours;
        int unknownCount = 0;
        // first iterate through the pattern to know how many ? characters there are
        // as well as the number of hours remaining
        for (int i = 0; i < pattern.Length; i++) {
            if (pattern[i] == '?') {
                unknownCount++;
            }
            else {
                remainingSum -= pattern[i] - '0';
            }
        }
        List<List<int>> permutations = new List<List<int>>();
        // get all the lists of work shifts that sum to the remaining number of hours
        // the number of work shifts in each list is the number of ? characters in pattern
        GeneratePermutations(permutations, workHours, unknownCount); 
        // after getting all the permutations, we need to iterate through the pattern
        // for each permutation to construct a list of schedules to return
        List<string> schedules = new List<string>();
        foreach (List<int> permutation in permutation) {
            StringBuilder newSchedule = new StringBuilder();
            int permCount = 0;
            for (int i = 0; i < pattern.Length(); i++) {
                if (pattern[i] == '?') {
                    newSchedule.Append(permutation[permCount]);
                    permCount++;
                }
                else {
                    newSchedule.Append(pattern[i]);
                }
            }
            schedules.Add(newSchedule.ToString());
        }
        return schedules;
    }
    
    public void GeneratePermutations(List<List<int>> permutations, int workHours, int unknownCount) {
        for (int i = 0; i <= workHours; i++) {
            List<int> permutation = new List<int>();
            permutation.Add(i);
            GeneratePermuationsHelper(permutations, permutation, workHours - i, unknownCount - 1); 
        }
    }
    public void GeneratePermutationsHelper(List<List<int>> permutations, List<int> permutation, int remainingHours, int remainingShifts){
        if (remainingShifts == 0 && remainingHours == 0) {
            permutations.Add(permutation);
            return;
        }
        if (remainingHours <= 0 || remainingShifts <= 0) {
            return;
        }
        for (int i = 0; i <= remainingHours; i++) {
            List<int> newPermutation = new List<int>(permutation);
            newPermutation.Add(i);
            GeneratePermutationsHelper(permutations, newPermutation, remainingHours - i, remainingShifts - 1);
        }     
    }
