     while (spPort.BytesToRead > 0)
            {
                carac = (char)spPort.ReadByte();
                if (carac != 08)
                {
                    m_mystring += carac;
                }
            }
