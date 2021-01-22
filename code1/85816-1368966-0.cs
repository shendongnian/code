    // Common interface for cloneable classes.
    public interface IPrototype : ICloneable {
        new IPrototype Clone();
    }
    
    // Generic interface for cloneable classes.
    // The 'TFinal' is finaly class (type) which should be cloned.
    public interface IPrototype<TFinal> where TFinal : IPrototype<TFinal> {
        new TFinal Clone();
    }
    
    // Base class for cloneable classes.
    // The 'TFinal' is finaly class (type) which should be cloned.
    public abstract class PrototypeBase<TFinal> : IPrototype<TFinal> where TFinal : PrototypeBase<TFinal> {
        public TFinal Clone() {
            TFinal ret = this.CreateCloneInstance();
            if ( null == ret ) {
                throw new InvalidOperationException( "Clone instance was not created." );
            }
    
            this.FillCloneInstance( ret );
            return ret;
        }
    
        // If overriden, creates new cloned instance
        protected abstract TFinal CreateCloneInstance();
    
        // If overriden, fill clone instance with correct values.
        protected abstract void FillCloneInstance( TFinal clone );
    
        IPrototype IPrototype.Clone() { return this.Clone(); }
        object ICloneable.Clone() { return this.Clone(); }
    }
    
    // Common interface for standalone class.
    public interface IMyStandaloneClass : IPrototype<IMyStandaloneClass> {
        string SomeText{get;set;}
        string SomeNumber{get;set;}
    }
    
    // The prototype class contains all functionality exception the clone instance creation.
    public abstract class MyStandaloneClassPrototype<TFinal> : PrototypeBase<TFinal>, IMyStandaloneClass where TFinal : MyStandaloneClassPrototype<TFinal> {
        public string SomeText {get; set;}
        public int SomeNumber {get; set}
    
        protected override FillCloneInstance( TFinal clone ) {
            // Now fill clone with values
            clone.SomeText = this.SomeText;
            clone.SomeNumber = this.SomeNumber;
        }
    }
    
    // The sealed clas contains only functionality for clone instance creation.
    public sealed class MyStandaloneClass : MyStandaloneClassPrototype<MyStandaloneClass> {
        protected override MyStandaloneClass  CreateCloneInstance() {
            return new MyStandaloneClass();
        }
    }
    
    public interface IMyExtendedStandaloneClass : IMyStandaloneClass, IPrototype<IMyExtendedStandaloneClass> {
        DateTime SomeTime {get; set;}
    }
    
    // The extended prototype of MyStandaloneClassPrototype<TFinal>.
    public abstract class MyExtendedStandaloneClassPrototype<TFinal> : MyStandaloneClassPrototype<TFinal> where TFinal : MyExtendedStandaloneClassPrototype<TFinal> {
        public DateTime SomeTime {get; set;}
    
        protected override FillCloneInstance( TFinal clone ) {
            // at first, fill the base class members
            base.FillCloneInstance( clone );
    
            // Now fill clone with values
            clone.SomeTime = this.SomeTime;
        }
    }
    
    public sealed class MyExtendedStandaloneClass : MyExtendedStandaloneClassPrototype<TFinal> {
        protected override MyExtendedStandaloneClass CreateCloneInstance() {
            return new MyExtendedStandaloneClass 
        }
    }
