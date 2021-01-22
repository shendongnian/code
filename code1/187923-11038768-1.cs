        public AltEnumerator Iterate(IterDIrection How )
        {
            switch (How)
            {
                case TwoDimArray<T>.IterDIrection.RghtLeftTopBottom:
                    return new AltEnumerator(GetRightLeft());
            }
            return new AltEnumerator(GetEnumerator());
        }
        private System.Collections.IEnumerator GetRightLeft()
        {
            for (int cndx = PutSlotArray.GetLength(1) - 1; cndx >= 0; cndx--)
                for (int rndx = 0; rndx < PutSlotArray.GetLength(0); rndx++)
                    if (PutSlotArray[rndx, cndx] != null)
                        yield return PutSlotArray[rndx, cndx];
        }
        #region IEnumerable Members
        public System.Collections.IEnumerator GetEnumerator()
        {
            foreach (T ps in PutSlotArray)
                if (ps != null)
                    yield return ps;
        }
        #endregion
