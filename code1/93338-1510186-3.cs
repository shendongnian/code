    Enumerable.Range(0, Math.Floor(2.52*Math.Sqrt(num)/Math.Log(num))).Aggregate(
        Enumerable.Range(2, num-1).ToList(), 
        (result, index) => { 
            result.RemoveAll(i => i > result[index] && i % result[index] == 0); 
            return result; 
        }
    );
