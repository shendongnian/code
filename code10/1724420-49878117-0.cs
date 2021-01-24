	private static Model1 FromMolde2(Model2 m2) {
		return new Model1 { Value = m2.Value };
	}
    public static Expression<Func<Model2, Model1>> GetExpression() {
        return f => FromMolde2(f);
    }
