	var start = new DateTime(2017, 1, 1);
	var end = new DateTime(2017, 12, 31, 23, 59, 59);
	IList<Contract> contracts = new List<Contract>(); // or anything enumerable
	var contractsSignedBetween = contracts.Where(x => x.SignDate.IsBetween(start, end));
	var contractsReleasedBetween = contracts.Where(x => x.ReleaseDate.IsBetween(start, end));
