    Analysis createAnalysis(int numberOfProducts) {
        SizeStrategy strategy;
        if (numberOfProducts <= SMALL) {
            strategy = new SmallStrategy();
        } else if (numberOfProducts <= MEDIUM) {
            strategy = new MediumStrategy();
        } else {
            strategy = new LargeStrategy();
        }
        return new Analysis(numberOfProducts, strategy);
    }
