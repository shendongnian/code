    public int sumPositiveNumbersR(int[] v, int n){
	int sum;
	if(n < 0) return 0; //stopCriterium
	else{
		if(v[n] > 0){
			sum = v[n] + sumPositiveNumbersR(v, n-1); //scrolls the vector and sum
			return sum;
		}else
			return sumPositiveNumbersR(v, n-1); //scrolls the vector
	}
