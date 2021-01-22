            _tourDal.Stub(x => x.GetById(new TourGet(2), null))
                .Constraints(new PredicateConstraint<TourGet>(y => y.TourId == 2), new Anything())
                .Return(
                new Tour() 
                {
                    TourId = 2,
                    DepartureLocation = new IataInfo() { IataId = 2 },
                    ArrivalLocation = new IataInfo() { IataId = 3 }
                });
