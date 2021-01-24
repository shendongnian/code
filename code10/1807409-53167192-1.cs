            public float Multiply(float a, float b)
            {
                using (new OperationScope(this)) //This is IDisposable and calls OnBeginAdd & OnEndAdd
                { 
                    return a * b;
                }
            }
