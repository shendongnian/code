public void RunMyGame()
{
    bool isFinish = false;
    while (!isFinish)
    {
        ShowWelcome();
        InitVars();
        PlayTheGame();
        // We reach here when the game is finished
        // Play again? 'Y' isFinish set to false then loop
        isFinish = PromptToPlayAgain();
    }
}
