        public abstract class BaseWithAbstraction<TSelf, TInterface, TParameter>
            where TSelf : BaseWithAbstraction<TSelf, TInterface, TParameter>, TInterface, new()
        {
            [Obsolete(FactoryMessage, true)]
            protected BaseWithAbstraction()
            {
            }
            protected const string FactoryMessage = "Use YourClass.Create(...) instead";
            public static TInterface Create(TParameter parameter)
            {
                var me = new TSelf();
                me.Initialize(parameter);
                return me;
            }
            protected virtual void Initialize(TParameter parameter)
            {
            }
        }
        public abstract class BaseWithParameter<TSelf, TInterface, TParameter> : BaseWithAbstraction<TSelf, TInterface, TParameter>
            where TSelf : BaseWithParameter<TSelf, TInterface, TParameter>, TInterface, new()
        {
            protected TParameter Parameter { get; private set; }
            [Obsolete(FactoryMessage, true)]
            protected BaseWithParameter()
            {
            }
            protected sealed override void Initialize(TParameter parameter)
            {
                this.Parameter = parameter;
                this.OnAfterInitialize(parameter);
            }
            protected virtual void OnAfterInitialize(TParameter parameter)
            {
            }
        }
        
        public class GraphicsDeviceManager
        {
        }
        public interface IDrawable
        {
            void Update();
            void Draw();
        }
        internal class Rectangle : BaseWithParameter<Rectangle, IDrawable, GraphicsDeviceManager>, IDrawable
        {
            [Obsolete(FactoryMessage, true)]
            public Rectangle()
            {
            }
            public void Update()
            {
                GraphicsDeviceManager manager = this.Parameter;
                // TODo  manager
            }
            public void Draw()
            {
                GraphicsDeviceManager manager = this.Parameter;
                // TODo  manager
            }
        }
        internal class Circle : BaseWithParameter<Circle, IDrawable, GraphicsDeviceManager>, IDrawable
        {
            [Obsolete(FactoryMessage, true)]
            public Circle()
            {
            }
            public void Update()
            {
                GraphicsDeviceManager manager = this.Parameter;
                // TODo  manager
            }
            public void Draw()
            {
                GraphicsDeviceManager manager = this.Parameter;
                // TODo  manager
            }
        }
        [Test]
        public void FactoryTest()
        {
            // doesn't compile because interface abstraction is enforced.
            Rectangle rectangle = Rectangle.Create(new GraphicsDeviceManager());
            // you get only the IDrawable returned.
            IDrawable service = Circle.Create(new GraphicsDeviceManager());
        }
