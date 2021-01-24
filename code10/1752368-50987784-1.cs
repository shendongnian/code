    List<Node> SortParents(List<Node> source) {
        if(source == null || source.Count == 0) return source;
        return 
            source
            .OrderBy(o => Convert.ToInt16(o.KaartNum))
            .ThenBy(o => o.Name)
            .Select(o => new Node() {
                Name = o.Name,
                Image = o.Image,
                Symbol = o.Symbol,
                KaartNum = o.KaartNum,
                children = SortChildren(o.children)
            })
            .ToList();
    }
    List<Node> SortChildren(List<Node> source) {
        if(source == null || source.Count == 0) return source;
        return 
            source
            .OrderBy(o => o.Name)
            .Select(o => new Node() {
                Name = o.Name,
                Image = o.Image,
                Symbol = o.Symbol,
                KaartNum = o.KaartNum,
                children = SortChildren(o.children)
            })
            .ToList();
    }
