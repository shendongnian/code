                XmlNodeList NodoEstudios = DocumentoXML.SelectNodes("//ALUMNOS/ALUMNO[@id=\"" + Id + "\"]/estudios");
                string Proyecto = "";
                foreach(XmlElement ElementoProyecto in NodoEstudios)
                {
                    XmlNodeList EleProyecto = ElementoProyecto.GetElementsByTagName("proyecto");
                    Proyecto = (EleProyecto[0] == null)?"": EleProyecto[0].InnerText;
                }
