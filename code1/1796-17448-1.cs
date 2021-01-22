    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Media.Imaging;
    
    namespace Codecs {
        class Program {
            static void Main(string[] args) {
                Console.WriteLine("Bitmap Encoders:");
                AllEncoderTypes.ToList().ForEach(t => Console.WriteLine(t.FullName));
                Console.WriteLine("\nBitmap Decoders:");
                AllDecoderTypes.ToList().ForEach(t => Console.WriteLine(t.FullName));
                Console.ReadKey();
            }
    
            static IEnumerable<Type> AllEncoderTypes {
                get {
                    return AllSubclassesOf(typeof(BitmapEncoder));
                }
            }
    
            static IEnumerable<Type> AllDecoderTypes {
                get {
                    return AllSubclassesOf(typeof(BitmapDecoder));
                }
            }
    
            static IEnumerable<Type> AllSubclassesOf(Type type) {
                var r = new Reflector();
                // Add additional assemblies here
                return r.AllSubclassesOf(type);
            }
        }
    
        class Reflector {
            List<Assembly> assemblies = new List<Assembly> { 
                typeof(BitmapDecoder).Assembly
            };
            public IEnumerable<Type> AllSubclassesOf(Type super) {
                foreach (var a in assemblies) {
                    foreach (var t in a.GetExportedTypes()) {
                        if (t.IsSubclassOf(super)) {
                            yield return t;
                        }
                    }
                }
            }
        }
    }
