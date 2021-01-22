          public static XElement
          GetNamespaceElement(this XElement element, string ns, string name)
          {
              XNamespace n = new XNamespace();
              n.NamespaceName = ns;
              return element.Element(n + name);
          }
