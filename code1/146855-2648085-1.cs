        private void ProcessDocument()
        {
            CodeElements elements = _applicationObject.ActiveDocument.ProjectItem.FileCodeModel.CodeElements;
            foreach (CodeElement element in elements)
            {
                if (element.Kind == vsCMElement.vsCMElementNamespace)
                {
                    CodeNamespace ns = (CodeNamespace)element;
                    foreach (CodeElement elem in ns.Members)
                    {
                        if (elem is CodeClass)
                        {
                            CodeClass cls = elem as CodeClass;
                            foreach (CodeElement member in cls.Members)
                                if (member is CodeProperty)
                                {
                                    CodeType memberType = ((member as CodeProperty)).Type.CodeType;
                                    ProcessElem(memberType as CodeElement);
                                }
                        }
                    }
                }
            }
        }
        private void ProcessElem(CodeElement elem)
        {
            if (null == elem) return;
            // we only care about elements that are classes or interfaces.
            if (elem is CodeClass)
            {
                CodeClass cls = elem as CodeClass;
                CodeElements intfs = cls.ImplementedInterfaces;
                // do whatever with intfs
                // ...
                CodeElements bases = cls.Bases;
                foreach (CodeElement baseElem in bases)
                    ProcessElem(baseElem);
            } 
            else if (elem is CodeInterface)
            {
                // same as class, figure out all other interfaces this interface 
                // derives from if needed
            }
        }
