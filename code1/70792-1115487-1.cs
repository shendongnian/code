    using System;
    using System.Xml.Serialization;
    [XmlType("foo"), XmlRoot("foo")]
    public class FooDto {
        [XmlAttribute("bar")]
        public string Bar { get; set; }
    
        public static implicit operator Foo(FooDto value) {
            return value == null ? null :
                new Foo(value.Bar);
        }
        public static implicit operator FooDto(Foo value) {
            return value == null ? null :
                new FooDto { Bar = value.Bar };
        }
    }
    public class Foo {
        private readonly string bar;
        public Foo(string bar) { this.bar = bar; }
        public string Bar { get { return bar; } }
    }
    static class Program {
        static void Main() {
            Foo foo = new Foo("abcdefg");
            FooDto dto = foo;
            new XmlSerializer(dto.GetType()).Serialize(
                Console.Out, dto);
        }
    }
