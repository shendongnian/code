    var src = new[] { 1, 2, 3, 4, 99, 5, 6, 7, 99, 8, 9, 10, 99 };
    
    var obs = src.ToObservable().Publish().RefCount();
    
    var windows =
    	obs
    	.Zip(
    		obs.Skip(2).Concat(Observable.Repeat(0, 2)),
    		(chase, lead) => (chase, lead))
    	.Publish(pub =>
    		pub
    		.Window(
    			pub.Where(x => x.lead == 99),
    			_ => pub.Skip(1)));
