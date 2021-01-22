        private void ProcessElem(CodeElement elem)
        {
            if (elem.Kind == vsCMElement.vsCMElementClass)
            {
                CodeClass cls = elem as CodeClass;
                CodeElements intfs = cls.ImplementedInterfaces;
                // do whatever with intfs
                // ...
                CodeElements bases = cls.Bases;
                foreach (CodeElement baseElem in bases)
                {
                    ProcessElem(baseElem);
                }      
            }
        }
