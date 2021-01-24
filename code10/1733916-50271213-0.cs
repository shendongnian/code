           //Separate out different entries from both the lists
			var diffList = AuthorList.Where(x => !AuthorList2.Any(y => y.ProductId== x.ProductId && y.Assigned== x.Assigned)).ToList();
           //Separate out common entries from both the list
			var commonList = AuthorList.Where(x => AuthorList2.Any(y => y.ProductId== x.ProductId && y.Assigned== x.Assigned)).ToList();
            //Change value of Assigned
			commonList.ForEach(x => x.Assigned = !x.Assigned);
           //Merge both the lists
           diffList.AddRange(commonList);
