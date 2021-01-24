            public static void WaitUntil(this IWebDriver driver, Func<bool> Condition, float timeout = 10f)
        {
            float timer = timeout;
            while (!Condition.Invoke() && timer > 0f) {
                System.Threading.Thread.Sleep(500);
                timer -= 0.5f;
            }
            System.Threading.Thread.Sleep(500);
        }
    driver.WaitUntil(() => driver.FindElements(By.XPath(".//*[contains(@class, 'block-ui-wrapper')]").Length == 0);
