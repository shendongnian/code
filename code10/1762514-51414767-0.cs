    private void ChangeOutput(string op)
        {
            foreach (CoreAudioDevice d in devices)
            {
                if (d.FullName == op)
                    d.SetAsDefault();
            }
        }
