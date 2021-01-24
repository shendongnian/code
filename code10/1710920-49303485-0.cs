    class Service
    {
        public void Run()
        {
            var model = new DerivedModel<DerivedRow>();
            var parser = new DerivedParser<DerivedModel<DerivedRow>, DerivedRow>(model);
        }
    }
    class DerivedModel<TRow> : AbstractModel<DerivedRow>
        where TRow : DerivedRow
    {
        public override DerivedRow NewRow()
        {
            return new DerivedRow();
        }
    }
    abstract class AbstractModel<TRow> where TRow : AbstractRow
    {
        public abstract TRow NewRow();
    }
    class DerivedRow : AbstractRow
    {
    }
    abstract class AbstractRow
    {
    }
    class DerivedParser<TModel, TRow> : AbstractParser<TModel, TRow>
            where TModel : AbstractModel<TRow> where TRow : AbstractRow
    {
        public DerivedParser(TModel model)
        {
            Model = model;
        }
        public override TModel Parse()
        {
            var row = Model.NewRow();
            return Model;
        }
    }
    abstract class AbstractParser<TModel, TRow> where TRow : AbstractRow
    {
        public TModel Model { get; protected set; }
        public abstract TModel Parse();
    }
