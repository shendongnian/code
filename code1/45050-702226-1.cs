    void process(int x, int y) {
        ResultImageData[x, y] = (byte)((CurrentImageData[x, y] * AlphaValue) +
            (AlphaImageData[x, y] * OneMinusAlphaValue));
    }
    ThreadPool pool(3); // 3 threads big
    int xSize = ResultImageData.GetLength(0);
    int ySize = ResultImageData.GetLength(1);
    
    for (int x = 0; x < xSize; x++) {
         for (int y = 0; y < ySize; y++)  {
             pool.schedule(x, y);  // this will add all tasks to the pool's work queue
         }
    }
    pool.waitTilFinished(); // wait until all scheduled tasks are complete
