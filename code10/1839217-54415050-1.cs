    var data = new List<ComplexRow>();
    var res = data.Select(x => new List<Row>  {
        new Row{ ID=x.ID1, NAME=x.NAME1,DESC=x.DESC1 },
        new Row{ ID=x.ID2, NAME=x.NAME2,DESC=x.DESC2 },
        new Row{ ID=x.ID3, NAME=x.NAME3,DESC=x.DESC3 },
            })
            .SelectMany(x=>x)
            .ToList();
