            ArrayList answer = new ArrayList();
            //if(A == null) return -1; 
            if ((answer.Count == null))
            {
                answer.Add(-1);
                return answer;
            }
            long sum0 = 0, sum1 = 0;
            for (int i = 0; i < A.Length; i++) sum0 += A[i];
            for (int i = 0; i < A.Length; i++)
            {
                sum0 -= A[i];
                if (i > 0)
                { sum1 += A[i - 1]; }
                if (sum1 == sum0)
                    answer.Add(i);
                    //return i;
            }
            //return -1;
            return answer;
        }
