    using System;
    using Spark;
    using Spark.FileSystem;
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public abstract class EmailView : AbstractSparkView
    {
        public User user { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // following are one-time steps
            // create engine
            var settings = new SparkSettings()
                .SetPageBaseType(typeof(EmailView));
            var templates = new InMemoryViewFolder();
            var engine = new SparkViewEngine(settings)
                         {
                             ViewFolder = templates
                         };
            // add templates
            templates.Add("sample.spark", @"Dear ${user.Name}, This is an email.Sincerely, Spark View Engine http://constanto.org/unsubscribe/${user.Id}");
            // following are per-render steps
            // render template
            var descriptor = new SparkViewDescriptor()
                .AddTemplate("sample.spark");
            var view = (EmailView)engine.CreateInstance(descriptor);
            view.user = new User { Id = 655321, Name = "Alex" };
            view.RenderView(Console.Out);
            Console.ReadLine();
        }
    }
