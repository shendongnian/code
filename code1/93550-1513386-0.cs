    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    public enum ControlType {
        Label, LinkLabel
    }
    [XmlRoot("controls")]
    public class ControlWrapper {
        [XmlElement("control")] public List<ControlDto> Controls { get; set; }
        public ControlWrapper() {
            Controls = new List<ControlDto>();
        }
    }
    public class ControlDto {
        [XmlAttribute("type")] public ControlType Type { get; set; }
        [XmlAttribute("caption")] public string Caption { get; set; }
        [XmlAttribute("x")] public int LocationX { get; set; }
        [XmlAttribute("y")] public int LocationY { get; set; }
    }
    static class Program {
        static void Main() {
            var model = new ControlWrapper {
                Controls = {
                    new ControlDto {
                        Type = ControlType.LinkLabel,
                        Caption = "This is LinkLabel's text",
                        LocationX = 170, LocationY = 40
                    }, new  ControlDto {
                        Type = ControlType.Label,
                        Caption = "This is Label's text",
                        LocationX = 170, LocationY = 50
                    }
                }
            };
            var ser = new XmlSerializer(typeof(ControlWrapper));
            ser.Serialize(Console.Out, model);
        }
    }
