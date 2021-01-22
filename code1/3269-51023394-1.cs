    		public static List<int> pageRangeToList(string pageRg, int Nmax = 0)
		{
			List<int> ls = new List<int>();
			int lb,ub,i;
			foreach (string ss in pageRg.Split(','))
			{
				if(int.TryParse(ss,out lb)){
					ls.Add(Math.Abs(lb));
				} else {
					var subls = ss.Split('-').ToList();
					lb = (int.TryParse(subls[0],out i)) ? i : 0;
					ub = (int.TryParse(subls[1],out i)) ? i : Nmax;
					ub = ub > 0 ? ub : lb; // if ub=0, take 1 value of lb
					for(i=0;i<=Math.Abs(ub-lb);i++) 
						ls.Add(lb<ub? i+lb : lb-i);
				}
			}
			Nmax = Nmax > 0 ? Nmax : ls.Max(); // real Nmax
			return ls.Where(s => s>0 && s<=Nmax).ToList();
		}
